import axios from 'axios';

const API_URL = 'https://localhost:5001/api/v1/empresa';

class EmpresaService {
    getAll() {
        return axios.get(API_URL).then(response => {
            return response.data;
        }).catch(async error => {
            if (error.response != undefined && error.response.status < 500)
                return error.response.data;

            throw new Error(error.response.data);
        });
    }
    
    add(param) {
        return axios.post(API_URL, param).then(response => {
            return response.data;
        }).catch(async error => {
            if (error.response != undefined && error.response.status < 500)
                return error.response.data;

            throw new Error(error.response.data);
        });
    }

    update(param) {
        console.log('Update:', param);

        return axios.put(API_URL, param).then(response => {
            console.log('Resposta de put:', response);

            return response.data;
        }).catch(async error => {
            if (error.response != undefined && error.response.status < 500)
                return error.response.data;

            throw new Error(error.response.data);
        });
    }

    delete(id) {
        console.log(id);

        return axios.delete(API_URL + '/' + id).then(response => {
            return response.data;
        }).catch(async error => {
            if (error.response != undefined && error.response.status < 500)
                return error.response.data;

            throw new Error(error.response.data);
        });
    }
}

export default new EmpresaService();