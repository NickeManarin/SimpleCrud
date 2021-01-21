<template>
    <nav class="hero is-almost-medium">
        <div class="hero-body has-text-centered">
            <div class="container">
                <b-loading :is-full-page="true" :active.sync="isLoading" :can-cancel="false"/>

                <div class="columns is-mobile is-centered">
                    <div class="column is-narrow">
                        <p class="has-text-weight-heavy title">{{ $t('nav.title') }}</p>
                    </div>
                </div>
            </div>
        </div>
    </nav>
</template>

<script>
    export default { 
        name: 'Navigation',

        data() {
            return {
                isLoading: false
            }
        },

        methods: {
            back() {
                this.$router.push('/');
            },

            async logout() {
                try {
                    this.isLoading = true;
                    await this.$store.dispatch('auth/logout');
                } catch (e) {
                    console.log('Error while trying to logout', e);
                    this.$buefy.snackbar.open(this.$t('nav.error.logout'));
                }
                finally {
                    this.$router.push('/signin');
                    this.isLoading = false;
                }
            }
        }
    }
</script>

<style lang="scss" scoped>
    @media screen and (max-width: 769px) {
        .title {
            font-size: 20pt !important;
        }
    }

    .hero.is-almost-medium .hero-body {
        padding-top: 70px;
        padding-bottom: 95px;
    }

    .has-text-weight-heavy {
        font-weight: 800;
        font-size: 32pt;
    }
</style>