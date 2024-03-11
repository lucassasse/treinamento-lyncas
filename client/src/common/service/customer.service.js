import ApiService from '@/common/api/api.service'

let apiBasePath = 'customer'

const CustomerService = {
    async search(search) {
        let { data } = await ApiService.get(`${apiBasePath}?search=${search}`)
        return data
    },

    async searchById(id) {
        let { data } = await ApiService.get(`${apiBasePath}/${id}`)
        return data
    },

    async searchFiltred(search, infos) { //pagination e //{page, pageNumber, search}
        let { data } = await ApiService.post(`${apiBasePath}/${search}`, infos)
        return data
    },

    async create(form) {
        let { data } = await ApiService.post(`${apiBasePath}`, form)
        return data
    },

    async edit(id, form) {
        let { data } = await ApiService.update(`${apiBasePath}`, id, form)
        return data
    },
 
    async delete(id) {
        let { data } = await ApiService.delete(`${apiBasePath}/${id}`)
        return data
    },
}

export default CustomerService


























/**
 * const ProdutosService = {
    // FUNÇÕES CRUD:
    async criar(form) {
        let { data } = await ApiService.post(${apiBasePath}, form)
        return data
    },
    async editar(form) {
        let { data } = await ApiService.put(${apiBasePath}, form)
        return data
    },
    async excluir(itemId) {
        let { data } = await ApiService.delete(${apiBasePath}/${itemId})
        return data
    },
    // Fornecedores:
    async adicionarFornecedor(form) {
        let { data } = await ApiService.put(${apiBasePath}/fornecedor/adicionar, form)
        return data
    },
    async removerFornecedor(form) {
        let { data } = await ApiService.delete(${apiBasePath}/fornecedor/remover?FornecedorId=${form.fornecedorId}&ProdutoId=${form.produtoId})
        return data
    },
    // FUNÇÕES DE OBTENÇÃO DE DADOS:
    async obterProduto(itemId) {
        let { data } = await ApiService.get(${apiBasePath}/${itemId})
        return data
    },
    async obterTodos(form) {
        let { data } = await ApiService.get(${apiBasePath}, form)
        return data
    }
}
 */