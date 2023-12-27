import { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

export const useSignalRConnection = (hubUrl) => {
  const [connection, setConnection] = useState(null);
  const [connected, setConnected] = useState(false);
  useEffect(() => {
    const newConnection = new signalR.HubConnectionBuilder()
      .withUrl(hubUrl, {})
      .withAutomaticReconnect()
      .build();

    setConnection(newConnection);
  }, [hubUrl]);

  useEffect(() => {
    connect();

    return () => {
      if (connection) {
        connection.stop().then(() => setConnected(false));
      }
    };
  }, [connection]);

  const connect = () => {
    if (connection) {
      connection
        .start()
        .then(() => setConnected(true))
        .catch((err) => console.log('Connection failed: ', err));
    }
  };

  return [connection, connected, connect];
};
