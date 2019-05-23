<template>
    <div v-if="book">
        <h3>{{book.title}}</h3>
        <p>Availability: {{book.stock ? 'Immediate from store' : 'Needs shipping from the warehouse'}}</p>
        <form @submit.stop.prevent="submitOrder">
            <div class="form-group">
                <label for="quantity-input">Quantity</label>
                <input type="number" v-model="quantity" class="form-control"
                       placeholder="Quantity" id="quantity-input" />
            </div>
            
            <button type="submit" class="btn btn-primary">Checkout</button>
        </form>
    </div>
</template>

<script>
    import axiosInstance from '../utils/axiosInstance';

    export default {
        name: 'BookPay',
        data() {
            return {
                book: {
                    id: this.$route.params.id,
                    title: 'Metro 2033 - HARDCODED',
                    stock: 2,
                    price: 10.5
                },
                quantity: Number
            }
        },
        async created() {
            this.book = (await axiosInstance.get(`/books/${this.$route.params.id}`)).data;
        },
        methods: {
            submitOrder() {
                const body = {
                    clientId: 1,
                    bookId: this.book.id,
                    quantity: this.quantity,
                    instantSell: false
                };
                axiosInstance.post('/orders', body);
                this.$router.push('/');
            }
        }
    }
</script>

<style scoped>
</style>