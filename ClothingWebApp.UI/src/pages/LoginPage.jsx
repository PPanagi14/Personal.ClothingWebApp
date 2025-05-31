import  { useState } from 'react';
import { TextField, Button, Box, Typography, Container  } from '@mui/material';
import Grid from '@mui/material/Grid2';
import {login} from '../auth/authService'; // Adjust the import based on your project structure
import BackgroundImg from '../assets/background.jpg'; // Adjust the import based on your project structure

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  // Handle form submission
  const handleSubmit = () => {
    login(email, password);
  };

  return (
    <Box sx={{
        minHeight: '100vh',
        minWidth: '100vw',
        backgroundImage: `url(${BackgroundImg})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
      }}>
    <Container maxWidth="xs">
      <Box
        sx={{
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center',
          justifyContent: 'center',
          mt: 8,
          p: 3,
          borderRadius: 2,
          boxShadow: 3,
          backgroundColor: 'rgba(255, 255, 255, 0.8)', // Semi-transparent background
          backdropFilter: 'blur(10px)', // Optional: adds a blur effect to the background
        }}
      >
        <Typography variant="h5" sx={{ mb: 2 }}>
          Login
        </Typography>
        <form onSubmit={handleSubmit} style={{ width: '100%' }}>
          <Grid container spacing={2}>
            {/* Email Input */}
            <Grid size={12}>
              <TextField
                fullWidth
                label="Email"
                variant="outlined"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </Grid>

            {/* Password Input */}
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
              <Typography variant="body2" color="textSecondary" align="center">
                Don&apos;t have an account? <a href="/register">Register</a>
              </Typography>
            </Grid>

            {/* Login Button */}
            <Grid size={12}>
              <Button
                fullWidth
                type="submit"
                variant="contained"
                color="primary"
              >
                Login
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
