import React, { useState } from 'react';
import axios from 'axios';

const Weather = () => {
  const [city, setCity] = useState('');
  const [weatherData, setWeatherData] = useState(null);

  const fetchData = async () => {
    try {
      const response = await axios.get(
        `https://freetestapi.com/api/v1/weathers?search=${city}`
      );
      if(response.data.length === 0)
        alert('City not found');
      else
        setWeatherData(response.data);
      setWeatherData(response.data);
      console.log(response.data); // You can see all the weather data in console log
    } catch (error) {
      console.error(error);
    }
  };

  const handleInputChange = (e) => {
    setCity(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchData();
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Enter city name"
          value={city}
          onChange={handleInputChange}
        />
        <button type="submit">Get Weather</button>
      </form>
      {weatherData ? (
        <>
          <h2>Weather Data</h2>
          {weatherData.map((data, index) => (
            <div key={index}>
              <p>City: {data.city}</p>
              <p>Country: {data.country}</p>
              <p>Temperature: {data.temperature}</p>
              <p>Description: {data.weather_description}</p>
              <p>Humidity: {data.humidity}</p>
              <p>Wind Speed: {data.wind_speed}</p>
            </div>
          ))}
        </>
      ) : (
        <p>Loading weather data...</p>
      )}
    </div>
  );
};

export default Weather;
