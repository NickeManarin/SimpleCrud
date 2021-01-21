<template>
    <div class="hero">
        <div class="hero-body has-text-centered">
            <p class="title">{{ $t('not-found.title') }}</p>

            <router-link class="has-text-dark is-expanded has-text-centered" to="/">
                {{ $t('not-found.back') }}
            </router-link>
        </div>
    </div>
</template>

<script>
    export default { }
</script>