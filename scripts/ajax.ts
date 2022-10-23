import axios from 'axios';

export default {
    get: (url: string) => axios({
        method: 'get',
        url: url
    })
};
