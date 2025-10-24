<template>
  <div class="bg-black text pt-3" :style="{ height: '100vh' }">
    <h1 class="text-center text-success">ContactOpedia</h1>
    <div class="container">
      <div class="row text-white p-2 mb-2">
        <div class="col-6">
          Owner Name: <input type="text" v-model="ownerName" />
        </div>
        <div class="col-6 text-end">
          Max Lucky Number: <input type="number" v-model.number="maxNumber" />
        </div>
      </div>
      <br /><br />
      <add-contact @add-contact="onAddContact"></add-contact>
      <div class="row">
        <div class="col-12" v-for="contact in contacts" :key="contact.name">
          <contact
            :name="contact.name"
            :phone="contact.phone"
            :email="contact.email"
            :ownerName="contact.ownerName"
            :isFavorite="contact.isFavorite"
            :maxLuckyNumber="maxNumber"
            @update-favorite="
              contact.isFavorite = onUpdateFavorite($event, contact.phone)
            "
          ></contact>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, reactive } from "vue";
import Contact from "./components/Contact.vue";
import AddContact from "./components/AddContact.vue";

const ownerName = ref("DotNetMastery");
const maxNumber = ref(100);
const contacts = reactive([
  {
    name: "Bhrugen",
    phone: 123123123,
    ownerName: ownerName,
    isFavorite: false,
  },
  {
    name: "Bella",
    phone: 434343434343,
    ownerName: ownerName,
    isFavorite: true,
  },
  {
    name: "Charlie",
    phone: 777777777,
    ownerName: ownerName,
    email: "ben@dotnetmastery.com",
    isFavorite: false,
  },
]);

function onAddContact(contact) {
  contact.ownerName = ownerName.value;
  contact.isFavorite = false;
  contacts.push(contact);
}

function onUpdateFavorite(oldValuesFromChildComponent, phoneNumberFromParent) {
  console.log(oldValuesFromChildComponent);
  return !oldValuesFromChildComponent.isFavorite;
}
</script>

<style></style>
