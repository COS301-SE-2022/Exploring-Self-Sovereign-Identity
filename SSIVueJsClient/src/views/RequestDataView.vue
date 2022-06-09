<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
  setup() {
    const list = ref([]);
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
    return { list, options };
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
    values(value: Array<string>) {
      this.data.attributes;
      console.log(value);
    },
  },
});
</script>

<template>
  <el-form :inline="true" class="form" :model="data">
    <!-- * User ID  -->
    <el-form-item label="User ID">
      <el-input v-model="data.id" placeholder="Please input"> </el-input>
    </el-form-item>
    <!-- * Attribute select -->
    <el-select
      @change="values"
      v-model="list"
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
  </el-form>
</template>

<style lang="scss">
.form {
  backdrop-filter: hue-rotate(30deg);
}
</style>
