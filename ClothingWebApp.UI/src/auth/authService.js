import api from "../api/axios";

export const login = async (email, password) => {
  const res = await api.post("/auth/logIn", { email, password });
  return res.data.token; 
};

export const register = async (data) => {
  await api.post("/auth/registerUser", data);
};

export const logout = () => {
  localStorage.removeItem("token");
};

export const askOllama = async (userMessage) => {
  const response = await api.post("/ollama/ask", { prompt: userMessage });
  return response;
};


  