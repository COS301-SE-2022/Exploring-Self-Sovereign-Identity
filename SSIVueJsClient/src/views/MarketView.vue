<script lang="ts">
import { defineComponent, ref } from "vue";
import { marketStore } from "@/stores/marketStore";
import { userDataStore } from "@/stores/userData";

export default defineComponent({
  setup() {
    const market = marketStore();
    const userData = userDataStore();
    const loading = ref(true);
    const arr = new Map<string, string>();
    return { market, loading, userData, arr };
  },
  mounted() {
    this.market
      .get()
      .then(() => {
        this.loading = false;
      })
      .catch((err) => {
        console.log(err);
      });
  },
  methods: {
    update(value: string, index: string) {
      this.arr.set(index, value);
    },
    async updateUser() {
      let changed = false;
      if (this.arr.size == 0) return;
      for (let [key, value] of this.arr) {
        if (value != "") {
          console.log("arr");
          console.log(key, value);
          this.userData.attributes.attributes.push({
            attribute: {
              name: key,
              value: value,
            },
            index: -1,
          });
          changed = true;
        } else {
          // * fix empty checks
          console.log("empty");
        }
      }
      console.log("here2");
      if (changed) {
        console.log("changed");
        await this.userData.setuserdata();
      }
      console.log("done");
    },
    exists(att: string) {
      const value = this.userData.getAttributes.find(
        (x) => x.attribute.name == att
      )?.attribute.value;
      if (value) {
        return value;
      } else {
        this.arr.set(att, "");
        return "";
      }
    },
    async approve(id: string, org: string) {
      // *
      this.loading = true;
      await this.updateUser();
      const attributes = new Map<string, string>();
      const att = this.market.getMarkets.find((x) => x.id == id)?.attributes;
      if (att) {
        for (let i = 0; i < att.length; i++) {
          attributes.set(att[i], "");
        }
      }
      for (let x of this.userData.getAttributes) {
        if (attributes.has(x.attribute.name)) {
          attributes.set(x.attribute.name, x.attribute.value);
        }
      }
      const atts = Array.from(attributes).map((x) => {
        return {
          name: x[0],
          value: x[1],
        };
      });
      await this.market.approve(org, id, atts).then(() => {
        this.$router.go(0);
      });
      // *
    },
  },
});
</script>

<template>
  <div>
    <n-skeleton
      v-if="loading"
      :sharp="false"
      size="medium"
      :repeat="7"
      height="6vh"
      width="99vw"
    />
    <template v-else>
      <n-card v-for="m in market.getMarkets" :key="m.id">
        <n-collapse accordion arrow-placement="right">
          <n-collapse-item :title="m.organization">
            <template #header-extra>
              <n-statistic label="ETH" tabular-nums :value="m.pricePerUnit">
                <template #suffix>
                  <n-icon name="eth" />
                </template>
              </n-statistic>
            </template>
            <n-input-group
              v-for="att in m.attributes"
              :key="att"
              data-test-id="attribute"
            >
              <n-input-group-label>{{ att }}</n-input-group-label>
              <n-input
                :key="att"
                :default-value="exists(att)"
                :readonly="exists(att) != ''"
                @input="update($event, att)"
              ></n-input>
            </n-input-group>
            <n-space>
              <n-button type="primary" @click="approve(m.id, m.organization)">
                Approve
              </n-button>
            </n-space>
          </n-collapse-item>
        </n-collapse>
      </n-card>
    </template>
  </div>
  <BackNav page="Market" />
</template>

<style lang="scss"></style>
