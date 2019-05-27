<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">GUID</th>
                <th scope="col">Quantity</th>
                <th scope="col">Title</th>
                <th scope="col">Price</th>
                <th scope="col">State</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in orders" :key="order.id">
                <th scope="row">{{order.guid}}</th>
                <td>{{order.quantity}}</td>
                <td>{{order.book.title}}</td>
                <td>{{order.totalPrice}}</td>
                <td>{{getState(order)}}</td>
            </tr>
        </tbody>
    </table>
</template>
<script>
    import axiosInstance from '../utils/axiosInstance';
    export default {
        name: 'Orders',
        data() {
            return {
                orders: []
            }
        },
        async created() {
            this.orders = (await axiosInstance.get(`/clients/${this.clientId}/orders`)).data;
        },
        methods: {
            getState(order) {
                var date = order.state.dispatchDate;
                var date_parsed = new Date(parseInt(date.substr(6))).toLocaleString("en-US", { year: 'numeric', month: 'long', day: 'numeric' });
                switch (order.state.type) {
                    case 0:
                        return "Waiting Expedition";
                    case 1:
                        return "Dispatched at " + date_parsed;
                    case 2:
                        return "Dispatch will occur at " + date_parsed;
                    default:
                        return "";
                }
            }  
        },
        computed: {
            clientId() {
                return this.$store.state.client.id;
            }
        },
        watch: {
            async clientId(newId) {
                this.orders = (await axiosInstance.get(`/clients/${newId}/orders`)).data;
            }
        }
    }
</script>
<style scoped>
</style>
