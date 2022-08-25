<template>
  <footer class="footer">
    <div>
      <a>Code of Duty</a>
    </div>

    <div class="divider">|</div>

    <div>
      <a>Self Sovereign Identity</a>
    </div>
  </footer>
</template>

<script lang="ts" setup>
import { useI18n } from 'vue-i18n'

import { Locale } from '@/enums'


</script>

<style lang="scss" scoped>
@use 'src/styles/var';

.footer {
  display: flex;
  align-items: center;
  justify-content: center;
  height: var.$layout-footer-height;
  padding: 0.8rem 0;
  color: rgba(var.$color-text, 0.4);
  font-weight: bold;
  font-size: 0.8rem;

  .divider {
    padding: 0 1rem;
  }

  .locale {
    cursor: pointer;
  }

  .link,
  .locale {
    transition: color 0.2s;

    &:hover {
      color: var.$color-text;
    }
  }
}
</style>
