import api from "../api/axios";

export const login = async (email, password) => {
  const res = await api.post("/auth/logIn", { email, password });
  return res.data.token; // ⛔ do NOT store here — return only
};

export const register = async (data) => {
  await api.post("/auth/registerUser", data);
};

export const logout = () => {
  localStorage.removeItem("token");
};

  