<script lang="ts">
import { values } from "lodash";
import { defineComponent, isReactive, isRef, reactive, ref } from "vue";
import BackNav from "../components/Nav/BackNav.vue";

export default defineComponent({
  setup() {
    const options = [
      {
        value: "Name",
        label: "Name",
      },
      {
        value: "Surname",
        label: "Surname",
      },
      {
        value: "Number",
        label: "Number",
      },
    ];
    return { options };
  },
  data() {
    return {
      data: {
        id: "",
        attributes: Array<string>(),
      },
    };
  },
  methods: {
    sendData() {
      console.log;
    },
  },
  components: { BackNav },
});
</script>

<template>
  <el-form :inline="true" class="form" :model="data" style="padding-top: 2vh">
    <!-- * User ID  -->
    <el-form-item label="User ID">
      <el-input
        v-model="data.id"
        placeholder="Please input"
        data-test-id="userid"
      >
      </el-input>
    </el-form-item>
    <!-- * Attribute select -->
    <el-form-item label="Perms">
      <el-select
        v-model="data.attributes"
        multiple
        placeholder="Attributes"
        style="width: 100%"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>
    </el-form-item>
    <el-form-item>
      <div class="submit">
        <el-button @click="sendData" plain type="primary" round
          >Request</el-button
        >
      </div>
    </el-form-item>
  </el-form>

  <BackNav page="Request Data" />
</template>

<style lang="scss">
.form {
  backdrop-filter: hue-rotate(10deg);
}
.submit {
  margin-top: 15vh;
  width: 100vw;
  text-align: center;
  button {
    margin-right: auto;
    margin-left: auto;
    // color: whitesmoke;
    // background-color: black;
  }
}
</style>
