import { Component } from '@angular/core';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.scss']
})
export class AppContentComponent {
  posts = Array.from({ length: 10 }).map((_, i) => ({
    title: `Sample Post ${i + 1}`,
    text: `This is an example post content #${i + 1}.`
  }));
}
