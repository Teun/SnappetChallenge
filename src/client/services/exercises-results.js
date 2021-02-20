import api from '../api';

const getAll = query => api.get('/exercises-results', {params: query});

export default {
  getAll
};
