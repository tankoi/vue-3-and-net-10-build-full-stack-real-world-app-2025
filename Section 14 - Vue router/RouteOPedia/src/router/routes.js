import { createRouter, createWebHistory } from "vue-router";
import HomePage from "@/components/Home/HomePage.vue";
import Contact from "@/components/Home/Contact.vue";
import ProductList from "@/components/Product/ProductList.vue";
import ProductDetail from "@/components/Product/ProductDetail.vue";
import NotFound from "@/components/Layout/NotFound.vue";
import NoAccess from "@/components/Layout/NoAccess.vue";
import Login from "@/components/Authentication/Login.vue";

function isAdmin() {
	const isAdmin = false;
	if (isAdmin) {
		return true;
	}
	return { name: "noAccess" };
}

function isAuthenticated() {
	const isAuthenticated = true;
	if (isAuthenticated) {
		return true;
	}
	return false;
}

const router = createRouter({
	history: createWebHistory(import.meta.env.BASE_URL),
	routes: [{
		path: "/",
		component: HomePage,
		name: "home",
	}, {
		path: "/contact-us",
		component: Contact,
		name: "contact",
	}, {
		path: "/contact",
		redirect: { name: "contact" },
	}, {
		path: "/no-access",
		component: NoAccess,
		name: "noAccess",
	}, {
		path: "/productList",
		component: ProductList,
		name: "productList",
		beforeEnter: [isAdmin, isAuthenticated],
	}, {
		path: "/login",
		component: Login,
		name: "login",
	}, {
		path: "/product/:productId/:categoryId?",
		component: ProductDetail,
		name: "productDetails",
		props: true,
	}, {
		path: "/product",
		component: ProductDetail,
	}, {
		path: "/:catchAll(.*)",
		component: NotFound,
	}],
	linkActiveClass: "active btn btn-primary",
});

router.beforeEach((to, from) => {
	console.log("Global beforeEach called");
	// check if the user is authenticated
	// if not redirect to login page
	const isAuthenticated = true;

	if (to.name === "home") {
		return true;
	}

	if (!isAuthenticated && to.name !== "login") {
		return { name: "login" };
	}
	return true;
});

export default router;
