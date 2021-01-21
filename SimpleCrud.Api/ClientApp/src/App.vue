<template>
  <div id="app">
    <div class="has-background"/>
    <div class="has-white-background" v-if="this.$route.path !== '/signin' && this.$route.path !== '/signup'"/>

    <Navigation/>
    <router-view class="fills-height"/>
    <Footer/>
  </div>
</template>

<script>
  import Navigation from './components/Navigation.vue'
  import Footer from './components/Footer.vue'

  const customIconConfig = {
    customIconPacks: {
      unicons: {
        iconPrefix: "uil-",
        internalIcons: {
          check: "check",
          information: "info-circle",
          "check-circle": "check-circle",
          alert: "exclamation-triangle",
          "alert-circle": "exclamation-circle",
          "arrow-up": "arrow-up",
          "chevron-right": "angle-right",
          "chevron-left": "angle-left",
          "chevron-down": "arrow-down",
          eye: "eye",
          "eye-off": "eye-slash",
          "menu-down": "angle-down",
          "menu-up": "angle-up",
          "close-circle": "times-circle"
        }
      },
      icon: {
          iconPrefix: "icon-",
      }
    }
  };

  export default {
    name: "app",

    components: {
      Navigation,
      Footer
    },

    created() {
      this.$buefy.config.setOptions(customIconConfig);
    }
  };
</script>

<style lang="scss">
  //Import Bulma's core
  @import "~bulma/sass/utilities/_all";
  @import "@/scss/icons.scss";

  //Custom colors.
  $primary: #89e7ff;
  $primary-inverted: findInverted($primary);

  $transparent: #00050505; //FFD836;
  $transparent-inverted: #000000;

  $colors: (
    "white": ($white, $black),
    "black": ($black, $white),
    "light": ($light, $light-invert),
    "dark": ($dark, $dark-invert),
    "primary": ($primary, $primary-invert),
    "info": ($info, $info-invert),
    "link": ($link, $link-invert),
    "success": ($success, $success-invert),
    "warning": ($warning, $warning-invert),
    "danger": ($danger, $danger-invert),
    "transparent": ($transparent, $transparent-inverted)
  );

  //Import Bulma and Buefy styles
  @import "~bulma";
  @import "~buefy/src/scss/buefy";

  //Custom global styles.
  html {
      background-color: #89e7ff;
      min-height:100%; /* make sure it is at least as tall as the viewport */
      position:relative;
  }

  body{
    height:100%; /* force the BODY element to match the height of the HTML element */
  }

  #app {
    font-family: "Raleway", BlinkMacSystemFont, -apple-system, "Helvetica Neue", Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;

    display: flex;
    min-height: 100vh;
    flex-direction: column;
  }

  .has-background {
    position: absolute;
    left: 0;
    right: 0;
    z-index: -1;
    display: block;
    height: 300px;
    background-size: cover;
    background-position: 50%;
    background-repeat: no-repeat;
    background-image: url("/img/background.svg");
    mask-image: linear-gradient(180deg, rgba(0,0,0,1) 80%, rgba(0,0,0,0) 100%);
  }

  .has-white-background {
    position: absolute;
    left: 0;
    right: 0;
    bottom: 0;
    top: 203px;
    z-index: -1;
    background-color: whitesmoke
  }

  .fills-height {
    flex: 1;
  }

  .icon.is-small {
    font-size: 14pt;
  }

  .icon.is-medium {
    font-size: 20pt;
  }

  .icon.is-large {
    font-size: 28pt;
  }
</style>