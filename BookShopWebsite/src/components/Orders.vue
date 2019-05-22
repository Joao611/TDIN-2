<template>
    <table class="table">
        <thead>
            <tr>
                <th scope="col">GUID</th>
                <th scope="col">Quantity</th>
                <th scope="col">Title</th>
                <th scope="col">Price</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="order in orders" :key="order.id">
                <th scope="row">{{order.guid}}</th>
                <td>{{order.quantity}}</td>
                <td>{{order.book.title}}</td>
                <td>{{order.totalPrice}}</td>
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
                orders: [{
                    guid: 0,
                    book: {
                        title: 'The Diary of a Wimpy Kid - HARDCODED',
                    },
                    quantity: 2,
                    totalPrice: 10.5
                }]
            }
        },
        async created() {
            this.orders = (await axiosInstance.get('/orders')).data;
        }
    }
</script>

<style scoped>
</style>