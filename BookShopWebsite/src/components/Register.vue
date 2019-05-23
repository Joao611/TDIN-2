<template>
    <form class="mt-2" @submit.stop.prevent="submitRegister">
        <div class="form-group">
            <label for="nameInput">Name</label>
            <input type="text" v-model="name" class="form-control" id="nameInput" aria-describedby="nameHelp" placeholder="Enter your name">
        </div>
        <div class="form-group">
            <label for="emailInput">E-mail</label>
            <input type="email" v-model="email" class="form-control" id="emailInput" aria-describedby="emailHelp" placeholder="Enter your e-mail">
        </div>
        <div class="form-group">
            <label for="addressInput">Address</label>
            <input type="text" v-model="address" class="form-control" id="addressInput" aria-describedby="addressHelp" placeholder="Enter your address">
        </div>

        <button type="submit" class="btn btn-primary">Register</button>
    </form>
</template>

<script>
    import axiosInstance from '../utils/axiosInstance';

    export default {
        name: 'Register',
        data() {
            return {
                email: '',
                name: '',
                address: '',
            }
        },
        methods: {
            async submitRegister() {
                const body = {
                    email: this.email,
                    name: this.name,
                    address: this.address,
                };
                try {
                    await axiosInstance.post('/clients', body);
                    this.$router.push('/');
                } catch (e) {
                    alert('Bad request');
                }
            }
        }
    }
</script>

<style scoped>
</style>