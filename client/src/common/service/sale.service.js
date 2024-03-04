import ApiService from '@/common/api/api.service'
import helpers from '@/common/helpers'

let apiBasePath = 'sale'

const SaleService = {
    async search(search) {
        let { data } = await ApiService.get(`${apiBasePath}?search=${search}`)

        data = data.map(sale => ({
            ...sale,
            saleDate: helpers.formatDate(sale.saleDate),
            billingDate: helpers.formatDate(sale.billingDate),
        }));
        
        return data
    },

    async searchById(id) {
        let { data } = await ApiService.get(`${apiBasePath}/${id}`)

        data.saleDate = helpers.formatDate(data.saleDate);
        data.billingDate = helpers.formatDate(data.billingDate);

        return data
    },

    async edit(id, form) {
        let { data } = await ApiService.put(`${apiBasePath}`, id, form)
        return data
    },

    async create(form) {
        let { data } = await ApiService.post(`${apiBasePath}`, form)
        return data
    },

    async delete(id) {
        let { data } = await ApiService.delete(`${apiBasePath}/${id}`)
        return data
    }
}

export default SaleService