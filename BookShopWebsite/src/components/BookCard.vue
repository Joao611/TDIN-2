<template>
    <router-link :to="`/book-pay/${book.id}`" tag="div" class="pointer">
        <div class="card">
            <div class="card-body">
                <div class="card-title">{{book.title}}</div>
                {{book.stock}}
                €{{book.price}}
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
                price: Number
            }
        }
    }
</script>

<style scoped>
</style>