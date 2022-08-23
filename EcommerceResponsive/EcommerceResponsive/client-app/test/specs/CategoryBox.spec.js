import test from 'ava'
import { mount } from '@vue/test-utils'
import CategoryBox from '@/components/CategoryBox.vue'
import chai from 'chai'

test('CategoryBox', (t) => {
  var expect = chai.expect;
  const wrapper = mount(CategoryBox, {
    propsData : {
        category: {
          nID:"1", 
          sName :"Case1",
          sDescription :"Test",
          sPrice :"50.00",
          sImageUrl :"s"
      }
    }
  })
  expect(wrapper.props().category.nID).to.include("1")
  expect(wrapper.props('category').nID).to.include("1")
  expect(wrapper.props().category.sName).to.include("Case1")
  expect(wrapper.props('category').sName).to.include("Case1")
  expect(wrapper.props().category.sDescription).to.include("Test")
  expect(wrapper.props('category').sDescription).to.include("Test")
  expect(wrapper.props().category.sPrice).to.include("50.00")
  expect(wrapper.props('category').sPrice).to.include("50.00")
  expect(wrapper.props().category.sImageUrl).to.include("s")
  expect(wrapper.props('category').sImageUrl).to.include("s")
  t.pass()
})
