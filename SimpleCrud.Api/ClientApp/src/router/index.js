import Vue from "vue";
import VueRouter from "vue-router";
import VueScrollTo from 'vue-scrollto';
import Home from "@/views/Home.vue";

Vue.use(VueRouter);

const routes = [
    {
        path: "/",
        name: "Home",
        component: Home,
        meta: {
            title: 'Company',
            requiresAuth: true
        }
    },
    {
        path: "/home",
        redirect: "/"
    },

    {
        path: "/404",
        name: "404",
        component: () => import(/* webpackChunkName: "NotFound" */ "@/views/NotFound.vue"),
        meta: {
            title: 'Customers - 404',
        }
    },
    {
        path: "*", //Everything else will result in a 404 page.
        redirect: "/404"
    }
];

const router = new VueRouter({
    mode: "history",
    base: process.env.BASE_URL,
    routes,

    scrollBehavior (to, from, savedPosition) {
        if (to.hash) {
            this.app.$scrollTo(to.hash, 700);
            return { selector: to.hash }
        } else if (savedPosition) {
            return savedPosition;
        } else {
            //When the route changes, the page should scroll back to the top.
            this.app.$scrollTo('#app', 700);
            return { x: 0, y: 0 }
        }
    }
});

router.afterEach((to, from) => {
    //If it's the same page, use the scrollBehavior (unless it's on the home page).
    if (to.hash && (to.path != from.path || to.path == "/"))
        Vue.nextTick().then(() => VueScrollTo.scrollTo(to.hash, 700));
});

export default router;