import Vue from 'vue';
import Router from 'vue-router';
import FormView from '@/views/FormView.vue';
import ResumeComponent from '@/components/ResumeComponent.vue';

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Form',
      component: FormView,
    },
    {
      path: '/resume',
      name: 'Resume',
      component: ResumeComponent,
      props: (route) => ({ formData: route.params.formData }),
    },
  ],
});
