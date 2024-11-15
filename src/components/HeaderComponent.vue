<template>
  <header class="header">
    <nav>
      <a 
        v-for="option in options" 
        :key="option" 
        :class="{ active: option === activeOption }" 
        @mouseover="hoveredOption = option"
        @mouseleave="hoveredOption = null"
        @click="setActive(option)">
        {{ option }}
      </a>
    </nav>
  </header>
</template>

<script>
export default {
  props: ['activeOption'],
  data() {
    return {
      options: ['Home', 'Chat', 'Settings'],
      hoveredOption: null
    };
  },
  methods: {
    setActive(option) {
      this.$emit('update:activeOption', option);
    }
  }
}
</script>

<style scoped>
.header nav a {
  color: #333;
  text-decoration: none;
  padding: 10px;
  transition: color 0.3s;
}

.header nav a.active {
  color: #1199CE;
  font-weight: bold;
}

.header nav a:hover {
  color: #1199CE;
}
</style>
