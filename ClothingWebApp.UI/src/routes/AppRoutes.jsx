// src/routes/AppRoutes.jsx
import { Routes, Route, Navigate } from "react-router-dom";
import LoginPage from "../pages/LoginPage";
import RegisterPage from "../pages/RegisterPage";
// import HomePage from "../pages/HomePage";
// import ProtectedRoute from "./ProtectedRoute";

function AppRoutes() {
  return (
    <Routes>
        <Route path="/" element={<Navigate to="/login" />} />
      <Route path="/login" element={<LoginPage />} />
      <Route path="/register" element={<RegisterPage />} />
      {/* <Route
        path="/"
        element={
          <ProtectedRoute>
            <HomePage />
          </ProtectedRoute>
        }
      /> */}
    </Routes>
  );
}

export default AppRoutes;
