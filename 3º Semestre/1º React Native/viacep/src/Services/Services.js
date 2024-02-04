// Import do axios para trbalhar com api's externas
import axios from "axios";

// url da API externa que será usada
const externalApiUri = `https://brasilaberto.com/api/v1/zipcode/`;

// criamos uma variável e atribuímos a ela a url da api
const api = axios.create({
    baseURL: externalApiUri
});

export default api;