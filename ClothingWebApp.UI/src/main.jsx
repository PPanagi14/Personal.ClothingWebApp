import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css' // Import global CSS
import App from './App' // Import the App component

// Render the App component inside the div with id "app"
ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)

  