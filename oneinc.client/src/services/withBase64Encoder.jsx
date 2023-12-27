import React, { useEffect, useState } from 'react';

const withBase64Encoder =
  (WrappedComponent) =>
  ({ connection, isConnected, ...props }) => {
    const [isEncoding, setIsEncoding] = useState(false);
    const [encodedString, setEncodedString] = useState('');

    useEffect(() => {
      if (isConnected) {
        connection.on('ReceiveCharacter', (character) => {
          setEncodedString((prevString) => prevString + character);
        });
      }

      return () => {
        if (isConnected) {
          connection.off('ReceiveCharacter');
        }
      };
    }, [connection, isConnected]);

    useEffect(() => {
      if (isConnected) {
        connection.on('EncodingComplite', () => {
          setIsEncoding(false);
        });
      }

      return () => {
        if (isConnected) {
          connection.off('EncodingComplite');
          setEncodedString('');
        }
      };
    }, [connection, isConnected]);
    const encodeString = (str) => {
      if (isConnected && !isEncoding) {
        setIsEncoding(true);
        setEncodedString('');
        connection
          .invoke('ConvertToBase64', str)
          .catch((err) => console.log(err));
      }
    };

    const cancelEncoding = () => {
      if (isConnected) {
        connection.stop().then(() => {
          connection.start();
          setIsEncoding(false);
          setEncodedString('');
        });
      }
    };

    return (
      <WrappedComponent
        encodeString={encodeString}
        cancelEncoding={cancelEncoding}
        encodedString={encodedString}
        isEncoding={isEncoding}
        isConnected={isConnected}
        {...props}
      />
    );
  };

export default withBase64Encoder;
