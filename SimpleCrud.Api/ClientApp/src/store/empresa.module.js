import EmpresaService from '../services/empresa.service';

export const empresa = {
    namespaced: true,
    state: {},

    actions: {
        getAll({ commit }) {
            return EmpresaService.getAll().then(
                async response => {
                    commit('getAllSuccess', response);
                    return Promise.resolve(response);
                },
                error => {
                    return Promise.reject(error);
                }
            );
        },
        add({ dispatch }, { params }) {
            return EmpresaService.add(params).then(
                async () => {
                    return await dispatch('getAll');
                },
                error => {
                    return Promise.reject(error);
                }
            );
        },
        update({ dispatch }, { params }) {
            return EmpresaService.update(params).then(
                async () => {
                    return await dispatch('getAll');
                },
                error => {
                    return Promise.reject(error);
                }
            );
        },
        delete({ dispatch }, { id }) {
            console.log(id);

            return EmpresaService.delete(id).then(
                async () => {
                    return await dispatch('getAll');
                },
                error => {
                    return Promise.reject(error);
                }
            );
        },
    },

    mutations: {
        getAllSuccess(state, response) {
            state.empresaLoadedTimestamp = Date.now();
            state.empresas = response;
        },
    }
};