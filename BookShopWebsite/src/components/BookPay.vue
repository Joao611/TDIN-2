<template>
    <div v-if="book">
        <h3>{{book.title}}</h3>
        <p>Availability: {{book.stock ? 'Immediate from store' : 'Needs shipping from the warehouse'}}</p>
        <form @submit="submitOrder">
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
                    id: 0,
                    title: 'Metro 2033 - HARDCODED',
                    stock: 2,
                    price: 10.5
                },
                quantity: Number
            }
        },
        async created() {
            this.book = await axiosInstance(`/books/${this.$route.params.id}`);
        },
        methods: {
            submitOrder(e) {
                e.preventDefault();
                const body = {};
                axiosInstance.post('/orders', body);
            }
        }
    }
</script>

<style scoped>
</style>