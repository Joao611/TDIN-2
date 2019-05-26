<template>
    <router-link :to="`/book-pay/${book.id}`" tag="div" class="pointer">
        <div class="card">
            <div class="card-body">
                <img :src="book.src">
                <div class="card-title">{{book.title}}</div>
                <div class="book-details">
                    <!--<span>{{book.stock}}</span>-->
                    <span>€{{book.price}}</span>
                </div>
                <!--<a :href="`/book-pay/${book.id}`" class="btn btn-primary">Checkout</a>-->
            </div>
        </div>
    </router-link>
</template>

<script>
    export default {
        name: 'BookCard',
        props: {
            book: {
                id: Number,
                title: String,
                stock: Number,
                price: Number,
                src: String
            }
        }
    }
</script>

<style scoped>
    div.card {
        margin-top: 20px;
    }
    div.card-title {
        font-weight: bold;
    }
    div.book-details {
        display: flex;
        justify-content: flex-end;
    }
    img {
        height: 165px;
        max-width: 140px;
    }

</style>