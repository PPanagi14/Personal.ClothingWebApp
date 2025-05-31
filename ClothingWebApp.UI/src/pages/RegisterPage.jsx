import {
  TextField,
  Button,
  Box,
  Typography,
  Container,
} from '@mui/material';
import Grid from '@mui/material/Grid2';
import { register as registerUser } from '../auth/authService';
import { useNavigate } from 'react-router-dom';
import BackgroundImg from '../assets/background.jpg';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';
import { registerSchema } from '../validation/registerSchema';

const Register = () => {
  const navigate = useNavigate();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(registerSchema),
  });

  const onSubmit = async (data) => {
    try {
      await registerUser(data);
      alert('Registration successful!');
      navigate('/login');
    } catch (err) {
      alert('Registration failed.');
      console.error(err);
    }
  };

  return (
    <Box
      sx={{
        minHeight: '100vh',
        minWidth: '100vw',
        backgroundImage: `url(${BackgroundImg})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        backgroundRepeat: 'no-repeat',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
      }}
    >
      <Container maxWidth="xs">
        <Box
          sx={{
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
            mt: 8,
            p: 3,
            borderRadius: 2,
            boxShadow: 3,
            backgroundColor: 'rgba(255, 255, 255, 0.8)',
            backdropFilter: 'blur(10px)',
          }}
        >
          <Typography variant="h5" sx={{ mb: 2 }}>
            Register
          </Typography>

          <form onSubmit={handleSubmit(onSubmit)} style={{ width: '100%' }}>
            <Grid container spacing={2}>
              {[
                { name: 'firstName', label: 'First Name' },
                { name: 'lastName', label: 'Last Name' },
                { name: 'email', label: 'Email' },
                { name: 'password', label: 'Password', type: 'password' },
                { name: 'phoneNumber', label: 'Phone Number' },
                { name: 'address', label: 'Address' },
                { name: 'city', label: 'City' },
                { name: 'state', label: 'State' },
                { name: 'zipCode', label: 'Zip Code' },
              ].map(({ name, label, type = 'text' }) => (
                <Grid key={name} size={12}>
                  <TextField
                    fullWidth
                    label={label}
                    type={type}
                    {...register(name)}
                    error={!!errors[name]}
                    helperText={errors[name]?.message}
                  />
                </Grid>
              ))}

              <Grid size={12}>
                <Typography variant="body2" align="center">
                  Already have an account? <a href="/login">Login</a>
                </Typography>
              </Grid>

              <Grid size={12}>
                <Button fullWidth type="submit" variant="contained" color="primary">
                  Register
                </Button>
              </Grid>
            </Grid>
          </form>
        </Box>
      </Container>
    </Box>
  );
};

export default Register;
