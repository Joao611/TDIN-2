import axios from 'axios';

const axiosInstance = axios.create({
    baseURL: 'http://localhost:8733/Design_Time_Addresses'
});

export default axiosInstance;