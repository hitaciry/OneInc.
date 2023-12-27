import React from 'react';
import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import EncoderForm from './components/EncoderForm';
import withSignalRConnection from './services/withSignalRConnection';
import withBase64Encoder from './services/withBase64Encoder';

const App = withSignalRConnection(
  withBase64Encoder(EncoderForm),
  'https://localhost:44337/hub'
);

export default App;
