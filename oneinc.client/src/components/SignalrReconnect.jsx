import React from 'react';
import { Button, Spinner, Stack } from 'react-bootstrap';

export const SignalrReconnect = ({ connect, isConnected, children }) => {
  if (isConnected) {
    return children;
  }
  return (
    <Stack direction='vertical' gap={3}>
      <Spinner className='m-auto'/>
      <>Connecting to server ... </>
      <Button onClick={connect}>Try to connect manually</Button>
    </Stack>
  );
};
