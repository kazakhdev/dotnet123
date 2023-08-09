import { useState, useCallback, useRef } from 'react';

export const useHttp = () => {
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);
  const [messages, setMessages] = useState(null);
  const dataRef = useRef(null); // Use useRef to store the data value

  const sendRequest = useCallback(async (url = 'https://localhost:5001/todo',  method = 'GET', body = null, headers = {}) => {
    setLoading(true);
    try {
      if (body) {
        if (headers['Content-Type'] !== 'multipart/form-data; charset=utf-8; boundary="--WebKitBoundary"') {
          body = JSON.stringify(body);
        }
        if (headers['Content-Type'] === undefined) {
          headers['Content-Type'] = 'application/json'
        }
      }
    
      const response = await fetch(url, { method, body, headers });
      const jsonData = await response.json();

      dataRef.current = jsonData; // Store the data value in the re
      setLoading(false);

      if (!response.ok) {
        setMessages(jsonData.errors);
        throw new Error(jsonData.message || 'Something went wrong...');
      }

      setError(null);
      return jsonData;
    } catch (e) {
      setLoading(false);
      setError(e.message);
      throw e;
    }
  }, []);

  const clearError = useCallback(() => setError(null), []);
  const clearMessages = useCallback(() => setMessages(null), []);

  return {
    loading,
    sendRequest,
    error,
    data: dataRef.current, // Return the data from the ref
    clearError,
    clearMessages,
    messages
  };
};
