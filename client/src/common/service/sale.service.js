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
    async delete(id) {
        let { data } = await ApiService.delete(`${apiBasePath}/${id}`)
        return data
    }
}

export default SaleService