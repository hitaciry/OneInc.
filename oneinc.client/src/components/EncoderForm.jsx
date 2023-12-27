import React, { useState } from 'react';
import { Button, Card, Form, Spinner, Stack } from 'react-bootstrap';
import './EncoderForm.css';
import { SignalrReconnect } from './SignalrReconnect';
import { useSignalRConnection } from '../hooks/useSignalRConnection';
import { useBase64Encoder } from '../hooks/useBase64Encoder';

const EncoderForm = () => {
  const apiUrl =
    /*process?.env?.REACT_APP_BACKEND_URL ||*/ 'https://localhost:44337';
  const [connection, isConnected, connect] = useSignalRConnection(
    `${apiUrl}/hub`
  );
  const [encodeString, cancelEncoding, encodedString, isEncoding] =
    useBase64Encoder(connection, isConnected);

  const [inputString, setInputString] = useState('');

  const handleInputChange = (event) => {
    setInputString(event.target.value);
  };

  const handleEncode = () => {
    encodeString(inputString);
  };

  return (
    <Card className='min-vw-50'>
      <Card.Body>
        <SignalrReconnect isConnected={isConnected} connect={connect}>
          <Form>
            <Form.Group className='mb-3' controlId='form.inputString'>
              <Form.Label>Input string</Form.Label>
              <Form.Control
                as='textarea'
                rows={3}
                value={inputString}
                onChange={handleInputChange}
                disabled={isEncoding}
                placeholder='Please, type your string here and press Submit button'
              />
            </Form.Group>
            <Form.Group className='mb-3' controlId='form.outputString'>
              <Form.Label>Output string</Form.Label>
              <Form.Control
                as='textarea'
                rows={3}
                value={encodedString}
                placeholder='You will see the result of Base64 encoding here'
                disabled
              />
            </Form.Group>

            <Stack direction='horizontal' gap={3}>
              {isEncoding ? <Spinner /> : <></>}
              <Button
                className='ms-auto'
                onClick={handleEncode}
                disabled={isEncoding}
              >
                Submit
              </Button>
              <Button variant='light' onClick={cancelEncoding}>
                Cancel
              </Button>
            </Stack>
          </Form>
        </SignalrReconnect>
      </Card.Body>
    </Card>
  );
};

export default EncoderForm;
