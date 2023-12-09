<template>
  <div v-if="show" class="text-danger">
    <div v-for="(m, i) in message" :key="i">
      {{ m }}
    </div>
  </div>
</template>

<script>
export default {
  props: {
    validation: {
      type: Object,
      required: true
    }
  },
  computed: {
    show() {
      return this.validation.$dirty && this.validation.$invalid;
    },
    message() {
      let message = [];
      if (this.validation.$dirty) {
        if (this.hasValidationError("required")) {
          message.push("*Please Enter a value.");
        } else if (this.hasValidationError("email")) {
          message.push("*Please Enter email.");
        }
      }
      return message;
    },
  },
  methods: {
    hasValidationError(type) {
      return (
        Object.prototype.hasOwnProperty.call(this.validation.$params, type) &&
        !this.validation[type]
      );
    },
  },
};
</script>

<style scoped>
</style>
