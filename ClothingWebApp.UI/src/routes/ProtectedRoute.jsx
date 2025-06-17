import { Navigate } from "react-router-dom";
import PropTypes from "prop-types";
import { useContext } from "react";
import { AuthContext } from "../context/AuthContext";
import jwtDecode from "jwt-decode";

function ProtectedRoute({ children }) {
  const { user } = useContext(AuthContext);

  if (!user || !user.token) return <Navigate to="/login" />;

  try {
    const decoded = jwtDecode(user.token);
    if (decoded.exp * 1000 < Date.now()) {
      return <Navigate to="/login" />;
    }
  } catch {
    return <Navigate to="/login" />;
  }

  return children;
}

ProtectedRoute.propTypes = {
  children: PropTypes.node.isRequired,
};

export default ProtectedRoute;
