import { createContext, useContext, useEffect, useState } from "react";
import PropTypes from "prop-types";
import { jwtDecode } from "jwt-decode"; // ✅ Correct for ES modules
import { login as loginApi, logout as logoutService } from "../auth/authService";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  // ⏳ Auto-login if token is already in localStorage
  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const payload = jwtDecode(token);
        setUser(parseUserFromPayload(token, payload));
      } catch {
        localStorage.removeItem("token");
        setUser(null);
      }
    }
  }, []);

  const login = async (email, password) => {
    const token = await loginApi(email, password);
    localStorage.setItem("token", token);
    const payload = jwtDecode(token);
    setUser(parseUserFromPayload(token, payload));
  };

  // 🔓 Logout and clear state
  const logout = () => {
    logoutService();
    setUser(null);
  };

  // 👤 Helper to extract user info + roles
  const parseUserFromPayload = (token, payload) => ({
  token,
  id: payload.id,
  email: payload.email,
  name: payload.name,
  roles: Array.isArray(payload.role) ? payload.role : [payload.role],
});


  return (
    <AuthContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
};

AuthProvider.propTypes = {
  children: PropTypes.node.isRequired,
};

export const useAuth = () => useContext(AuthContext);
