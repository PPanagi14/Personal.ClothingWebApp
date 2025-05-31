import * as yup from 'yup';

export const registerSchema = yup.object().shape({
  firstName: yup.string()
    .required('First name is required')
    .max(50, 'First name must be less than 50 characters'),

  lastName: yup.string()
    .required('Last name is required')
    .max(50, 'Last name must be less than 50 characters'),

  email: yup.string()
    .required('Email is required')
    .email('Invalid email format'),

  password: yup.string()
    .required('Password is required')
    .min(8, 'Password must be at least 8 characters long')
    .matches(/[A-Z]/, 'Must contain at least one uppercase letter')
    .matches(/[a-z]/, 'Must contain at least one lowercase letter')
    .matches(/[0-9]/, 'Must contain at least one number')
    .matches(/[^a-zA-Z0-9]/, 'Must contain at least one special character'),

  phoneNumber: yup.string()
    .required('Phone number is required')
    .matches(/^\+?[1-9]\d{1,14}$/, 'Invalid phone number format'),

  address: yup.string()
    .required('Address is required'),

  city: yup.string()
    .required('City is required'),

  state: yup.string()
    .required('State is required'),

  zipCode: yup.string()
    .required('Zip code is required')
    .matches(/^\d{4,9}$/, 'Zip code must be between 4 and 9 digits')
});

