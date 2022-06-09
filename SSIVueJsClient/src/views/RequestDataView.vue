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
  methods: {},
  components: { BackNav },
});
</script>

<template>
  <el-form :inline="true" class="form" :model="data">
    <!-- * User ID  -->
    <el-form-item label="User ID">
      <el-input v-model="data.id" placeholder="Please input"> </el-input>
    </el-form-item>
    <!-- * Attribute select -->
    <el-form-item label="User ID">
      <el-select
        v-model="data.attributes"
        multiple
        placeholder="Attributes"
        style="width: 240px"
      >
        <el-option
          v-for="item in options"
          :key="item.value"
          :label="item.label"
          :value="item.value"
        />
      </el-select>
    </el-form-item>
  </el-form>

  <BackNav />
</template>

<style lang="scss">
.form {
  backdrop-filter: hue-rotate(30deg);
}
</style>
