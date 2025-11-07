import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/components/Home/HomePage.vue";
import Contact from "@/components/Home/Contact.vue";

const router = createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	routes: [{
		path: "/",
		component: HomePage,
	}, {
		path: "/contact",
		component: Contact,
	}],
});

export default router;
