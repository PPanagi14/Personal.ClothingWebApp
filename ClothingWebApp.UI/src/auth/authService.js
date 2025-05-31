import api from "../api/axios";

export const login = async (email, password) => {
  const res = await api.post("/auth/logIn", { email, password });
  localStorage.setItem("token", res.data.token);
};

export const register = async (data) => {
  await api.post("/auth/registerUser", data);
};

export const logout = () => {
  localStorage.removeItem("token");
};
