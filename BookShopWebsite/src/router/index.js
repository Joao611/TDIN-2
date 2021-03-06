﻿import Vue from 'vue'
import Router from 'vue-router'
import Books from '@/components/Books'
import Orders from '@/components/Orders'
import BookPay from '@/components/BookPay'
import Register from '@/components/Register'

Vue.use(Router)

export default new Router({
    routes: [
        {
            path: '/',
            name: 'Books',
            component: Books
        },
        {
            path: '/orders',
            name: 'Orders',
            component: Orders
        },
        {
            path: '/book-pay/:id',
            name: 'BookPay',
            component: BookPay
        },
        {
            path: '/register',
            name: 'Register',
            component: Register
        }
    ]
})
