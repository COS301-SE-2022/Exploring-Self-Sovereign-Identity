<script lang="ts">
import BackNav from "../components/Nav/BackNav.vue";
import { defineComponent, ref } from "vue";
import { userDataStore } from "@/stores/userData";
import { Add } from "@vicons/ionicons5";
import { useMessage } from "naive-ui";

export default defineComponent({
  setup() {
    const userData = userDataStore();
    const message = useMessage();

    return { userData, message };
  },
  data() {
    return {
      name: "",
      value: "",
      showModal: false,
      change: false,
    };
  },
  components: {
    BackNav,
    Add,
  },
  methods: {
    showMod() {
      this.showModal = true;
    },
    addAtt() {
      this.userData.attributes.attributes.push({
        attribute: {
          name: this.name,
          value: this.value,
        },
        index: -1,
      });
      this.change = true;
    },

    async submitForm() {
      this.saving;
      await this.userData
        .setuserdata()
        .then(() => {
          this.message.destroyAll();
          this.message.success("saved");
        })
        .catch(() => {
          this.message.destroyAll();
          this.message.error("could not save information");
        });
      this.change = false;
    },
    goBack() {
      this.$router.back();
    },
    changeVar() {
      this.change = true;
    },
    saving() {
      this.message.loading("saving...", {
        duration: 20000,
      });
    },
  },
});
</script>

<template>
  <!-- * Naive tabs -->
  <n-tabs type="bar" size="large" justify-content="space-evenly">
    <n-tab-pane name="Attributes">
      <n-input-group
        v-for="att in userData.getAttributes"
        :key="att.attribute.name"
        data-test-id="attribute"
      >
        <n-input-group-label>{{ att.attribute.name }}</n-input-group-label>
        <n-input
          :default-value="att.attribute.value"
          v-model.trim="att.attribute.value"
          @on-change="changeVar"
        ></n-input>
      </n-input-group>

      <n-space justify="center" size="small" class="space" item-style="object">
        <n-button
          strong
          secondary
          circle
          type="primary"
          size="large"
          @click="showMod"
          class="button"
        >
          Add Attribute
          <template #icon>
            <n-icon><Add /></n-icon>
          </template>
        </n-button>
        <n-collapse-transition :show="change" :appear="true">
          <n-button
            strong
            secondary
            circle
            type="primary"
            size="large"
            @click="submitForm"
            class="button"
          >
            Save
          </n-button>
        </n-collapse-transition>
      </n-space>
    </n-tab-pane>

    <n-tab-pane name="Credentials">
      <n-collapse accordion>
        <n-collapse-item
          v-for="cred in userData.getCredentials"
          :key="cred.organization"
          :title="cred.organization"
        >
          <n-input-group
            v-for="att in cred.attributes"
            :key="att.name"
            data-test-id="attribute"
          >
            <n-input-group-label>{{ att.name }}</n-input-group-label>
            <n-input :value="att.value" v-model="att.value"></n-input>
          </n-input-group>
        </n-collapse-item>
      </n-collapse>
    </n-tab-pane>
  </n-tabs>

  <!-- *Modal -->
  <n-modal
    v-model:show="showModal"
    preset="dialog"
    title="Add attribute"
    positive-text="Add"
    negative-text="Cancel"
    @positive-click="addAtt"
  >
    <n-space vertical>
      <n-input v-model:value="name" type="text" placeholder="Attribute name" />
      <n-input
        v-model:value="value"
        type="text"
        placeholder="Attribute value"
      />
    </n-space>
  </n-modal>
  <!-- * -->
  <BackNav page="Profile" />
</template>

<style lang="scss">
.icon {
  background-color: rgba(255, 255, 255, 0);
  height: auto;
  width: auto;
  max-width: 25vw;
}

.info {
  width: 98vw;
  margin-left: auto;
  margin-right: auto;
  margin-top: 2vh;
}

.id {
  background-color: black;
  color: white;
}
.innerCollapse {
  padding-left: 5vw;
}
.info-main {
  width: 100%;
  padding: 0% !important;
}
.collapse {
  // background-color: rgba(255, 255, 255, 0.5);
  width: 100%;
  border-radius: 5px;
  border-width: thin;
  div {
    // background-color: rgba(255, 255, 255, 0.5);
    border-radius: 5px;
    border-width: thin;
  }
}

.button {
  width: fit-content;
  padding: 4vw;
}
.space {
  margin-left: auto;
  margin-right: auto;
  left: 0;
  right: 0;
  position: fixed;
  bottom: 6.5vh;
  text-align: center;
}
</style>
