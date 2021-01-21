<template>
    <div class="footer" :class="{ 'has-accent': $route.fullPath.startsWith('/detail') }">
        <div class="columns is-mobile is-centered is-multiline">
            <div class="column has-text-centered">
                <div class="is-inline">
                    <h4 class="subtitle is-size-5 has-text-grey is-unselectable">{{ $t('footer.language') }}</h4>

                    <b-dropdown v-model="$i18n.locale" aria-role="list" position="is-top-right">
                        <button class="button" type="button" slot="trigger">
                            <template>
                                <b-icon class="left-icon" pack="icon" icon="localization"/>
                                <span>{{ $i18n.locale }}</span>                                           
                            </template>

                            <b-icon pack="unicon" icon="uil-angle-down"/>
                        </button>

                        <b-dropdown-item v-for="(lang, i) in languageArray" :key="`lang${i}`" :value="lang.info.code" aria-role="listitem">
                            <div class="media">
                                <div class="media-content">
                                    <h3>{{lang.info.lang}}</h3>
                                </div>
                            </div>
                        </b-dropdown-item>
                    </b-dropdown>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { languages } from '@/locales';

    export default {
        name: 'Footer',

        data() {
            return {
                languageArray: languages
            };
        },
    }
</script>

<style lang="scss" scoped>
    .footer {
        background-color: transparent;
        width:100%;
        padding: 3rem 1.5rem;
    }

    .column {
        padding: 0;
    }

    .is-semi-transparent {
        opacity: 0.2;
    }

    .has-accent {
        background-color: whitesmoke;
    }
</style>