<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">#</th>
                <th scope="col">Quantity</th>
                <th scope="col">Title</th>
                <th scope="col">Price</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in orders" :key="order.id">
                <th scope="row">{{order.id}}</th>
                <td>{{order.quantity}}</td>
                <td>{{order.title}}</td>
                <td>{{order.price}}</td>
            </tr>
        </tbody>
    </table>
</template>

<script>
    export default {
        name: 'Orders',
        data() {
            return {
                orders: [{
                    id: 0,
                    title: 'The Diary of a Wimpy Kid - HARDCODED',
                    quantity: 2,
                    price: 10.5
                }]
            }
        },
        async created() {
            orders = await axiosInstance.get('/orders');
        }
    }
</script>

<style scoped>
</style>