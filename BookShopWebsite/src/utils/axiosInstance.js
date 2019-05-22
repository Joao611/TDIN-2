import axios from 'axios';

axios.defaults.withCredentials = false;
const axiosInstance = axios.create({
    baseURL: 'http://localhost:8733/Design_Time_Addresses/StoreHost/StoreService',
    withCredentials: false,
});

export default axiosInstance;