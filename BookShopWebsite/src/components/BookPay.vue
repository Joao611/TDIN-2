<template>
    <div class="container" v-if="book">
        <img :src="book.src" />
        <div class="order-info">
            <span>
                <h3>{{book.title}}</h3>
                <p>Available stock: {{book.stock}}</p>
            </span>
            <form @submit.stop.prevent="submitOrder">
                <div class="form-group">
                    <label for="quantity-input">Quantity</label>
                    <input type="number" v-model="quantity" class="form-control"
                           placeholder="Quantity" id="quantity-input" />
                </div>

                <button type="submit" class="btn btn-primary">Checkout</button>
            </form>
        </div>
        
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
                    price: 10.5,
                    src: ""
                },
                quantity: Number
            }
        },
        async created() {
            this.book = (await axiosInstance.get(`/books/${this.$route.params.id}`)).data;
            let index = parseInt(this.$route.params.id) - 1;
            this.book.src = this.$store.state.images[index];
        },
        methods: {
            async submitOrder() {
                const body = {
                    clientId: this.$store.state.client.id,
                    bookId: this.book.id,
                    quantity: this.quantity,
                    instantSell: false,
                };
                try {
                    await axiosInstance.post('/orders', body);
                    this.$router.push('/orders');
                } catch (e) {
                    alert('Bad request');
                }
            }
        }
    }
</script>

<style scoped>
    div.container img {
        width: 450px;
        height: 450px;
    }
    div.container {
        display: flex;
        margin-top: 20px;
    }

    div.order-info {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        margin-left: 20px;
    }
</style>