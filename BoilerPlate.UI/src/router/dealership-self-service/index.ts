import { RouteConfig } from 'vue-router'
import internalRoutes from '@/constants/internalRoutes'

import DealershipSelfService from '@/views/dealership-self-service/DealershipSelfService.vue'
import DealershipHome from '@/views/dealership-self-service/sub-routes/DealershipHome.vue'
import EditDealer from '@/views/dealership-self-service/sub-routes/EditDealer.vue'

const DealershipWorkflow: RouteConfig = {
    path: internalRoutes.dealershipSelfService,
    redirect: internalRoutes.dealershipSelfService + '/home',
    name: 'Dealership Self Service',
    component: DealershipSelfService,
    children: [
        {
            name: 'Home',
            path: 'home',
            meta: { title: '' },
            component: DealershipHome
        },
        {
            name: 'EditDealer',
            path: 'edit-dealer',
            meta: { title: 'Edit Dealer' },
            component: EditDealer
        }
    ]
}

export default DealershipWorkflow
