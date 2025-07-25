import { useState } from "react";
import {
  TextField,
  Button,
  Box,
  Typography,
  Container,
} from "@mui/material";
import Grid from "@mui/material/Grid2";
import BackgroundImg from "../assets/background.jpg";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState(null); 
  const navigate = useNavigate();
  const { login,user } = useAuth();
  const [loading, setLoading] = useState(false);


 const handleSubmit = async (e) => {
  e.preventDefault();
  setError(null);
  setLoading(true); // 🔁 start loading

  try {
    await login(email, password);
    console.log("Login successful",user);
    navigate("/"); // or role-based redirect (see below)
  } catch (err) {
    setError("Invalid email or password.");
    console.error("Login error:", err);
  } finally {
    setLoading(false); // ✅ stop loading
  }
};


  return (
    <Box
      sx={{
        minHeight: "100vh",
        minWidth: "100vw",
        backgroundImage: `url(${BackgroundImg})`,
        backgroundSize: "cover",
        backgroundPosition: "center",
        backgroundRepeat: "no-repeat",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Container maxWidth="xs">
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            justifyContent: "center",
            mt: 8,
            p: 3,
            borderRadius: 2,
            boxShadow: 3,
            backgroundColor: "rgba(255, 255, 255, 0.8)",
            backdropFilter: "blur(10px)",
          }}
        >
          <Typography variant="h5" sx={{ mb: 2 }}>
            Login
          </Typography>

          {error && (
            <Typography color="error" sx={{ mb: 2 }}>
              {error}
            </Typography>
          )}

          <form onSubmit={handleSubmit} style={{ width: "100%" }}>
            <Grid container spacing={2}>
              <Grid size={12}>
                <TextField
                  fullWidth
                  label="Email"
                  variant="outlined"
                  value={email}
                  onChange={(e) => setEmail(e.target.value)}
                />
              </Grid>

              <Grid size={12}>
                <TextField
                  fullWidth
                  label="Password"
                  type="password"
                  variant="outlined"
                  value={password}
                  onChange={(e) => setPassword(e.target.value)}
                />
              </Grid>

              <Grid size={12}>
                <Typography variant="body2" align="center">
                  Don&apos;t have an account?{" "}
                  <a href="/register">Register</a>
                </Typography>
              </Grid>

              <Grid size={12}>
                <Button
                  fullWidth
                  type="submit"
                  variant="contained"
                  color="primary"
                  disabled={loading}
                >
                  {loading ? "Logging in..." : "Login"}
                </Button>

              </Grid>
              <Grid size={12}>
                <Button
                  fullWidth
                  variant="contained"
                  color="primary"
                  onClick={() => navigate("/chatBot")}
                  disabled={loading}
                >
                  ChatBot
                </Button>

              </Grid>
            </Grid>
          </form>
        </Box>
      </Container>
    </Box>
  );
};

export default Login;
